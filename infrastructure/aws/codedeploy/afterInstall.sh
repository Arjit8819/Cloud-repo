#!/bin/bash

sudo rm -rf /home/centos/WebApp/logs
sudo systemctl restart kestrel.service
sudo /opt/aws/amazon-cloudwatch-agent/bin/amazon-cloudwatch-agent-ctl -a fetch-config -m ec2 -c file:/home/centos/WebApp/cloudwatch-config.json -s
